import React from 'react';
import About from '../views/About/index';

class AboutContainer extends React.Component {
	constructor(props) {
		super(props);
		this.state = {};
	}

	render() {
		return <About />;
	}
}

AboutContainer.propTypes = {};

export default AboutContainer;
