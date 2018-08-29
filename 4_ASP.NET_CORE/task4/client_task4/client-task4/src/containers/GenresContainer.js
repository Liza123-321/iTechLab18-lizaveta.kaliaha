import React from 'react';
import Genre from '../views/Genre/index';
import '../App.css';
import Film from '../views/Film/index';
import GenreRepository from '../repository/genre';

const genreRepository = new GenreRepository();
class GenresContainer extends React.Component {
	constructor(props) {
		super(props);
		this.setGenre = this.setGenre.bind(this);
		this.state = {
			genres: [],
			currentGenre: 'all',
			films: [],
		};
	}
	async componentDidMount() {
		let res = await genreRepository.getGenres();
		if (res.status === 200) {
			this.setState({ genres: res.data });
		}
	}
	async setGenre(genre) {
		this.setState({ currentGenre: genre.target.id });
		let res = await genreRepository.getFilmsByGenre(genre.target.id);
		if (res.status === 200) {
			this.setState({ films: res.data.films });
		}
	}
	eachTask = i => {
		return (
			<Genre name={i.genreName} setGenre={this.setGenre} key={i.genreName} />
		);
	};
	eachTaskFilms = i => {
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
				<div className="App-genres">{this.state.genres.map(this.eachTask)}</div>
				{this.state.currentGenre !== 'all' && (
					<div className="App-text"> {this.state.currentGenre} Films:</div>
				)}
				<div className="App-films">
					{this.state.films.map(this.eachTaskFilms)}
				</div>
				<hr />
			</div>
		);
	}
}
export default GenresContainer;
