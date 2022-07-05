import React from 'react';


const FormChoiceGenres = function ({ genres, changeArray }) {
    return (
        <form>
            <div><strong>Choose genres:</strong></div>
            <div className="form__genres">
                {genres.map(genre =>
                    <label key={genre.id} style={{ cursor: 'pointer', display: "flex", alignItems: 'center', flexBasis: "33.33333%" }}>
                        <input
                            type='checkbox'
                            onChange={(e) => changeArray(e, genre)}
                        />
                        {genre.title}
                    </label>
                    )}
            </div>
        </form>
    );
};
export default FormChoiceGenres;