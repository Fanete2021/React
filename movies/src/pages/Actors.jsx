import React, { useEffect, useState } from 'react';
import ActorService from '../API/ActorService';
import ActorForm from '../components/UI/Actor/ActorForm';
import ActorList from '../components/UI/Actor/ActorList';
import MyButton from '../components/UI/Button/Button';
import Creator from '../components/UI/Creator/Creator';
import Loader from '../components/UI/Loader/Loader';
import PageNavigation from '../components/UI/PageNavigation/PageNavigation';
import { useFetching } from '../hooks/UseFetching';
import { getPageCount } from '../utils/pages';

function Actors() {
    const [visibleCreature, setVisibleCreature] = useState(false);
    const [actors, setActors] = useState([])
    const [totalPagesActors, setTotalPagesActors] = useState(0)
    const [limitActors, setLimitActors] = useState(10)
    const [pageActors, setPageActors] = useState(1)

    const [fetchActors, isActorsLoading, actorError] = useFetching(async (limit, page) => {
        const response = await ActorService.getActors('', [], limit, page);

        const totalCountActors = response.headers['x-total-count']
        setTotalPagesActors(getPageCount(totalCountActors, limitActors))

        setActors(response.data)
    })

    useEffect(() => {
        fetchActors(limitActors, pageActors)
    }, [])

    const createActor = async (newActor) => {
        await ActorService.addActor(newActor)

        newActor = {
            ...newActor, id: await ActorService.getLast()
        }

        if (actors.length < 10) {
            setActors([...actors, newActor])
        }
        else if (pageActors === totalPagesActors) {
            setTotalPagesActors(totalPagesActors + 1)
        }

        setVisibleCreature(false);
    }

    const removeActor = async (actor) => {
        await ActorService.deleteActor(actor.id)
        let offset = 0
        
        if (pageActors !== 1 && actors.length === 1) {
            offset = 1
            setPageActors(pageActors - 1)
        }

        fetchActors(limitActors, pageActors - offset)
    }

    const changePage = (newValue) => {
        if (newValue > 0 && newValue <= totalPagesActors) {
            setPageActors(newValue)
            fetchActors(limitActors, newValue)
        }
    }

    return (
        <div className="infoBlock">
            <MyButton style={{ marginTop: 30 }} onClick={() => setVisibleCreature(true)}>
                Add a new actor
            </MyButton>

            {visibleCreature &&
                <Creator setVisible={setVisibleCreature} >
                    <ActorForm create={createActor} />
                </Creator>
            }
            <hr style={{ margin: '15px 0' }} />

            {actorError &&
                <h1>${actorError}</h1>
            }

            <ActorList remove={removeActor} actors={actors} title="Actors" />
            {isActorsLoading &&
                <div className="loader"><Loader /></div>
            }

            <PageNavigation totalPages={totalPagesActors} isLoading={isActorsLoading} page={pageActors} changePage={changePage} />
        </div>
    )
}


export default Actors;

