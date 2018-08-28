import React from 'react';
import Genre from '../views/Genre/index';
import '../App.css';
import GenreRepository from '../repository/genre';

const genreRepository = new GenreRepository();
class GenresContainer extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			genres: [],
		};
	}
	async componentDidMount() {
		let res = await genreRepository.getGenres();
		if (res.status === 200) {
			this.setState({ genres: res.data });
		}
	}
	eachTask = i => {
		return <Genre name={i.genreName} />;
	};
	render() {
		return (
			<div className="App-genres">{this.state.genres.map(this.eachTask)}</div>
		);
	}
}
export default GenresContainer;
