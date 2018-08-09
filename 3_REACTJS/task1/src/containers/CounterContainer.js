import React from 'react';
import Counter from '../views/Counter/index';
import PropTypes from 'prop-types';

class CounterContainer extends React.Component{
    constructor(props){
        super(props);
        this.decrementCounter=this.decrementCounter.bind(this);
        this.incrementCounter=this.incrementCounter.bind(this);
        this.resetCounter=this.resetCounter.bind(this);
        this.state={
            counter: 0,
        }
    };

    resetCounter(){
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
    render(){
        return(
    <Counter incrementFunction={this.incrementCounter}
             resetFunction={this.resetCounter}
             decrementFunction={this.decrementCounter}
             counterValue={this.state.counter}/>
        );
    }
}
CounterContainer.propTypes={
    incrementFunction:PropTypes.func,
    resetFunction: PropTypes.func,
    decrementFunction: PropTypes.func,
    counterValue: PropTypes.number
};

export default CounterContainer;