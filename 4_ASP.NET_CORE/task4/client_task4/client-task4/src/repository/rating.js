import axios from 'axios/index';
import FilmRepository from './film';
let config = {
	headers: {
		'Content-Type': 'application/json',
	},
};

axios.defaults.headers.common['Authorization'] = sessionStorage.getItem(
	'jwt_token'
);
axios.defaults.headers.common['Content-Type'] = 'application/json';

const filmRepository = new FilmRepository();
export default class RatingRepository {
	setRating = (mark, filmId, self) => {
		let obj = {
			mark: mark * 2,
			userId: 0,
			filmId: filmId,
		};
		let token = sessionStorage.getItem('jwt_token');
		config.headers['Authorization'] = 'Bearer ' + token;
		axios
			.post('https://localhost:5001/api/rating', JSON.stringify(obj), config)
			.then(async function() {
				self.props.alert.show('You success set rating', { type: 'success' });
				let answer = await filmRepository.getFilm(self.state.id);
				self.setState({ rating: answer.data.averageRating });
			})
			.catch(() => {
				self.props.alert.show('You should login', { type: 'error' });
				sessionStorage.removeItem('jwt_token');
			});
	};
}
