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
		this.state = {
			filmData: {},
			id: this.props.match.params.id,
		};
	}
	componentDidMount() {
		let self = this;
		axios
			.get(`https://localhost:5001/api/film/` + self.state.id)
			.then(function(res) {
				console.log(res.data);
				self.setState({ filmData: res.data });
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
					filmRating={this.state.filmData.averageRating}
					videoUrl={this.state.filmData.video}
				/>
				<PhotoGalleryContainer id={this.state.id} />
				<AddCommentContainer id={this.state.id} />
			</div>
		);
	}
}
FilmContainer.propTypes = {};

export default FilmContainer;
