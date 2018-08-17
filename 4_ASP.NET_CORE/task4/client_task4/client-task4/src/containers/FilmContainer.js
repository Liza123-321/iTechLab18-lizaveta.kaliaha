import React from 'react';
import FilmInfo from '../views/FilmInfo/index';
import axios from 'axios';
import '../App.css';
import PropTypes from 'prop-types';

class FilmContainer extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			filmId: 1,
			filmData: {},
		};
	}
	componentDidMount() {
		var self = this;
		axios
			.get(`https://localhost:5001/api/film/` + self.state.filmId)
			.then(function(res) {
				console.log(res.data);
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
			/>
		);
	}
}
FilmContainer.propTypes = {};

export default FilmContainer;
