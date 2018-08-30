import axios from 'axios';

let config = {
	headers: {
		'Content-Type': 'application/json',
	},
};

axios.defaults.headers.common['Content-Type'] = 'application/json';

export default class PhotoRepository {
	getPhotos = filmId => {
		return axios.get(
			'https://localhost:5001/api/photogallery/' + filmId,
			config
		);
	};
}
