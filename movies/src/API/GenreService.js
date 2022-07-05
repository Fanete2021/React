import axios from "axios";
import { server } from "./config";

export default class GenreService {
    static async getGenres() {
        const response = await axios.get(server + 'genres')
        return response.data;
    }
}