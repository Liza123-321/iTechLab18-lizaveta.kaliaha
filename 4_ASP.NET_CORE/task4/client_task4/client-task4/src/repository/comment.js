import axios from 'axios/index';

axios.defaults.headers.common['Authorization'] =
	'Bearer ' + sessionStorage.getItem('jwt_token');
axios.defaults.headers.common['Content-Type'] = 'application/json';

export default class CommentRepository {
	getComments = filmId => {
		return axios.get('https://localhost:5001/api/comments/' + filmId);
	};

	addComment = (filmId, commentMsg, self) => {
		let now = new Date();
		let config = {
			headers: {
				Authorization: 'Bearer ' + sessionStorage.getItem('jwt_token'),
			},
		};
		axios
			.post(
				`https://localhost:5001/api/comments/`,
				{
					commentMessage: commentMsg,
					filmId: filmId,
					data:
						now.getDate() +
						'/' +
						now.getMonth() +
						'/' +
						now.getFullYear() +
						' ' +
						now.getHours() +
						':' +
						now.getMinutes() +
						':' +
						now.getSeconds(),
				},
				config
			)
			.then(function() {
				self.props.alert.show('Success add comment', { type: 'success' });
				self.setState({ commentMessage: '' });
			})
			.catch(() => {
				self.props.alert.show('You should login', { type: 'error' });
				sessionStorage.removeItem('jwt_token');
			})
			.then(async function() {
				let res = await axios.get(
					'https://localhost:5001/api/comments/' + filmId
				);
				if (res.status === 200) {
					self.setState({ comments: res.data });
				}
			});
	};
}
