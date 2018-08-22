import React from 'react';
import FilmInfo from '../views/FilmInfo/index';
import axios from 'axios';
import '../App.css';
import PropTypes from 'prop-types';
import PhotoGalleryContainer from './PhotoGalleryContainer';

import AddCommentContainer from './AddCommentContainer';

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
	componentDidMount() {
		let self = this;
		axios
			.get(`https://localhost:5001/api/film/` + self.state.id)
			.then(function(res) {
				self.setState({ filmData: res.data });
				self.setState({ rating: res.data.averageRating });
			});
	}
	ratingChanged = newRating => {
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
			.then(function() {
				alert('You success set rating');
				axios
					.get(`https://localhost:5001/api/film/` + self.state.id)
					.then(function(res) {
						self.setState({ rating: res.data.averageRating });
					});
			})
			.catch(res => {
				alert(res.toString());
				sessionStorage.removeItem('jwt_token');
			});
	};
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
FilmContainer.propTypes = {};

export default FilmContainer;
