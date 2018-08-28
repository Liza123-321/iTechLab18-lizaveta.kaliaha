import axios from 'axios/index';

axios.defaults.headers.common['Authorization'] =
	'Bearer ' + sessionStorage.getItem('jwt_token');
axios.defaults.headers.common['Content-Type'] = 'application/json';

export default class GenreRepository {
	getGenres = () => {
		return axios.get('https://localhost:5001/api/genre');
	};
}
