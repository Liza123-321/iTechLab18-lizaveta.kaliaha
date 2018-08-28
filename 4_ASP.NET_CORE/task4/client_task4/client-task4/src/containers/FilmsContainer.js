import React from 'react';
import Film from '../views/Film/index';
import '../App.css';
import FilmRepository from '../repository/film';
import GenreContainer from './GenresContainer';

const filmRepository = new FilmRepository();

class FilmsContainer extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			countFilms: 0,
			arrayFilms: [],
		};
	}

	async componentDidMount() {
		let answer = await filmRepository.getFilms();
		if (answer.status === 200) {
			this.setState({ arrayFilms: answer.data });
		}
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
			<div>
				<GenreContainer />
				<div className="App-films">
					{this.state.arrayFilms.map(this.eachTask)}
				</div>
			</div>
		);
	}
}

export default FilmsContainer;
