import React from 'react';
import ParentCounter from '../views/ParentCounter/index';
import CounterContainer from './CounterContainer';

class ParentCounterContainer extends React.Component {
	constructor(props) {
		super(props);
		this.addCounterContainer = this.addCounterContainer.bind(this);
		this.resetCounterContainer = this.resetCounterContainer.bind(this);
		this.removeCounterContainer = this.removeCounterContainer.bind(this);
		this.eachTask = this.eachTask.bind(this);
		this.state = {
			countCounter: 1,
			counterContainers: [0],
			command: 'start',
		};
	}

	addCounterContainer() {
		var arr = this.state.counterContainers;
		this.setState({ countCounter: this.state.countCounter + 1 });
		this.setState({ command: 'add' });
		arr.push(this.state.countCounter);
		this.setState({ counterContainers: arr });
		console.log(this.state.counterContainers);
	}

	resetCounterContainer() {
		this.setState({
			command: 'reset',
			counterContainers: [0],
			countCounter: 1,
		});
	}

	removeCounterContainer() {
		if (this.state.countCounter > 1) {
			this.setState({ command: 'remove' });
			var arr = this.state.counterContainers;
			arr.splice(this.state.countCounter - 1);
			this.setState({ countCounter: this.state.countCounter - 1 });
			this.setState({ counterContainers: arr });
			console.log(this.state.counterContainers);
		} else console.log('only 1 countContainer');
	}

	eachTask = i => {
		return <CounterContainer key={i} command={this.state.command} />;
	};

	//LifeCycle
	componentDidMount() {
		console.log('Lifecycle: Parent componentDidMount.');
	}

	componentWillUnmount() {
		console.log('Lifecycle: Parent componentWillUnmount.');
	}

	componentDidUpdate() {
		console.log('Lifecycle: Parent componentDidUpdate.');
	}

	// getDerivedStateFromProps(nextProps) {
	//     console.log("Lifecycle: Parent getDerivedStateFromProps.");
	// }
	// getSnapshotBeforeUpdate() {
	//     console.log("Lifecycle: Parent getSnapshotBeforeUpdate.");
	// }
	shouldComponentUpdate(nextProps, nextState) {
		console.log('Lifecycle: Parent shouldComponentUpdate.');
		return true;
	}

	componentWillReceiveProps(nextProps) {
		console.log('Lifecycle: Parent componentWillRecieveProps.');
	}

	render() {
		console.log('Lifecycle: Parent render.');
		return (
			<div>
				<ParentCounter
					countCounter={this.state.countCounter}
					addFunction={this.addCounterContainer}
					resetFunction={this.resetCounterContainer}
					removeFunction={this.removeCounterContainer}
				/>
				<div>{this.state.counterContainers.map(this.eachTask)}</div>
			</div>
		);
	}
}

export default ParentCounterContainer;
