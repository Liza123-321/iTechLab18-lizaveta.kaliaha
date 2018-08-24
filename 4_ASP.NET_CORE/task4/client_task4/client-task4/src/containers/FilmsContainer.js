import React from 'react';
import Film from '../views/Film/index';
import axios from 'axios';
import '../App.css';

class FilmsContainer extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			countFilms: 0,
			arrayFilms: [],
		};
	}
	componentDidMount() {
		var self = this;
		axios.get(`https://localhost:5001/api/film`).then(function(res) {
			self.setState({ arrayFilms: res.data });
			self.setState({ countFilms: res.data.Count });
		});
	}
	eachTask = i => {
		return (
			<Film
				key={i.id}
				filmPoster={i.poster}
				filmName={i.name}
				filmId={i.id}
				filmRating={i.averageRating}
			/>
		);
	};
	render() {
		return (
			<div className="App-films">
				{this.state.arrayFilms.map(this.eachTask)}
			</div>
		);
	}
}

export default FilmsContainer;
