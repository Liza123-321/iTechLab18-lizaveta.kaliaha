import React from 'react';
import Counter from '../views/Counter/index';
import PropTypes from 'prop-types';

class CounterContainer extends React.Component {
	constructor(props) {
		super(props);
		this.decrementCounter = this.decrementCounter.bind(this);
		this.incrementCounter = this.incrementCounter.bind(this);
		this.resetCounter = this.resetCounter.bind(this);
		this.state = {
			counter: 0,
		};
	}

	resetCounter() {
		console.log('reset Counter');
		this.setState({ counter: 0 });
	}

	incrementCounter() {
		console.log('increment Counter');
		this.setState({ counter: this.state.counter + 1 });
	}

	decrementCounter() {
		console.log('decrement Counter');
		this.setState({ counter: this.state.counter - 1 });
	}

	//LifeCycle
	componentDidMount() {
		console.log('Lifecycle: Counter componentDidMount.');
	}

	componentWillUnmount() {
		console.log('Lifecycle: Counter componentWillUnmount.');
	}

	componentDidUpdate() {
		console.log('Lifecycle: Counter componentDidUpdate.');
	}

	componentWillReceiveProps(nextProps) {
		console.log('Lifecycle: Counter componentWillRecieveProps.');
		if (nextProps.command === 'add' && this.state.counter % 2 === 0) {
			this.setState({ counter: this.state.counter + 1 });
		} else if (nextProps.command === 'remove' && this.state.counter % 2 !== 0) {
			this.setState({ counter: this.state.counter - 1 });
		} else if (nextProps.command === 'reset') {
			this.setState({ counter: 0 });
		}
		return true;
	}

	// getDerivedStateFromProps() {
	//     console.log("Lifecycle: Counter getDerivedStateFromProps.");
	// }
	// getSnapshotBeforeUpdate(prevProps, prevState) {
	//     console.log("Lifecycle: Counter getSnapshotBeforeUpdate.");
	//     return null;
	// }
	shouldComponentUpdate(nextProps, nextState) {
		console.log('Lifecycle: Counter shouldComponentUpdate.');
		if (nextState.counter === this.state.counter) {
			return false;
		} else return true;
	}

	render() {
		console.log('Lifecycle: Counter render.');
		return (
			<Counter
				incrementFunction={this.incrementCounter}
				resetFunction={this.resetCounter}
				decrementFunction={this.decrementCounter}
				counterValue={this.state.counter}
			/>
		);
	}
}

CounterContainer.propTypes = {
	command: PropTypes.string.isRequired,
};

export default CounterContainer;
