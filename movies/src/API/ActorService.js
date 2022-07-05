import axios from "axios";
import { server } from "./config";
import { objectToQueryString } from "./serialize";

export default class ActorService {
    static async getActors(substr = '', bannedId = [], limit = 10, page = 1) {
        const response = await axios.get(server + 'actors', {
            params: {
                limit: limit,
                page: page,
                substr: substr,
                bannedId: bannedId
            },
            paramsSerializer: objectToQueryString
        })

        return response;
    }

    static async addActor(actor) {
        await axios.post(server + 'actors', actor)
    }

    static async getLast() {
        const response = await axios.get(server + 'actors/last');
        return response.data.id
    }

    static async deleteActor(id) {
        await axios.delete(server + 'actors/' + id)
    }
}