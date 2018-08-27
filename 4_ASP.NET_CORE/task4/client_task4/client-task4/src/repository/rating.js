import axios from 'axios/index';
let config = {
	headers: {
		'Content-Type': 'application/json',
	},
};

axios.defaults.headers.common['Authorization'] = sessionStorage.getItem(
	'jwt_token'
);
axios.defaults.headers.common['Content-Type'] = 'application/json';

export default class RatingRepository {
	setRating = (mark, filmId) => {
		let obj = {
			mark: mark * 2,
			userId: 0,
			filmId: filmId,
		};
		let self = this;
		let token = sessionStorage.getItem('jwt_token');
		config.headers['Authorization'] = 'Bearer ' + token;
		axios
			.post('https://localhost:5001/api/rating', JSON.stringify(obj), config)
			.then(async () => {
				alert('You success set rating!');
			})
			.catch(e => {
				alert('You should login!');
				sessionStorage.removeItem('jwt_token');
			});
	};
}
