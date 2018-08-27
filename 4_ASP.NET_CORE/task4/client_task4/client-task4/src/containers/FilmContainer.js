import React from 'react';
import FilmInfo from '../views/FilmInfo/index';
import axios from 'axios';
import { withAlert } from 'react-alert';
import '../App.css';
import FilmRepository from '../repository/film';
import PhotoGalleryContainer from './PhotoGalleryContainer';
import AddCommentContainer from './AddCommentContainer';

const filmRepository = new FilmRepository();
class FilmContainer extends React.Component {
	constructor(props) {
		super(props);
		this.ratingChanged = this.ratingChanged.bind(this);
		this.state = {
			filmData: {},
			id: this.props.match.params.id,
			rating: 0,
			isAuth: sessionStorage.getItem('jwt_token') != null,
		};
	}
	async componentDidMount() {
		let answer = await filmRepository.getFilm(this.state.id);
		if (answer.status === 200) {
			this.setState({ filmData: answer.data });
			this.setState({ rating: answer.data.averageRating });
		}
	}
	ratingChanged(newRating) {
		let config = {
			headers: {
				Authorization: 'Bearer ' + sessionStorage.getItem('jwt_token'),
			},
		};
		let self = this;
		axios
			.post(
				`https://localhost:5001/api/rating`,
				{
					mark: newRating * 2,
					userId: 0,
					filmId: self.state.id,
				},
				config
			)
			.then(async function() {
				self.props.alert.show('You success set rating', { type: 'success' });
				let answer = await filmRepository.getFilm(self.state.id);
				self.setState({ rating: answer.data.averageRating });
			})
			.catch(() => {
				self.props.alert.show('You should login', { type: 'error' });
				sessionStorage.removeItem('jwt_token');
			});
	}

	render() {
		return (
			<div>
				<FilmInfo
					filmPoster={this.state.filmData.poster}
					filmName={this.state.filmData.name}
					filmId={this.state.filmData.id}
					filmDescription={this.state.filmData.description}
					filmYear={this.state.filmData.year}
					filmCountry={this.state.filmData.country}
					filmProducer={this.state.filmData.producer}
					filmRating={this.state.rating}
					videoUrl={this.state.filmData.video}
					isAuth={this.state.isAuth}
					ratingChanged={this.ratingChanged}
				/>
				<PhotoGalleryContainer id={this.state.id} />
				<AddCommentContainer id={this.state.id} />
			</div>
		);
	}
}

export default withAlert(FilmContainer);
