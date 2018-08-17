import React from 'react';
import FilmInfo from '../views/FilmInfo/index';
import axios from 'axios';
import '../App.css';
import PropTypes from 'prop-types';

class FilmContainer extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			filmData: {},
		};
	}
	//убрать эту дичь
	componentDidMount() {
		let self = this;
		let strId = this.props.history.location.pathname.replace(
			/\/React_task1/g,
			''
		);
		axios.get(`https://localhost:5001/api` + strId).then(function(res) {
			self.setState({ filmData: res.data });
		});
	}
	render() {
		return (
			<FilmInfo
				filmPoster={this.state.filmData.poster}
				filmName={this.state.filmData.name}
				filmId={this.state.filmData.id}
				filmDescription={this.state.filmData.description}
				filmYear={this.state.filmData.year}
				filmCountry={this.state.filmData.country}
				filmProducer={this.state.filmData.producer}
				filmRating={this.state.filmData.averageRating}
			/>
		);
	}
}
FilmContainer.propTypes = {};

export default FilmContainer;
