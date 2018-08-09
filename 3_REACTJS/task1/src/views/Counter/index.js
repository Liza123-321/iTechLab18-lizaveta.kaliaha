import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import {withStyles} from "@material-ui/core/styles/index";
import styles from './style'


class Counter extends React.Component{
    render(){
        const { classes } = this.props;
        return(
            <div>
                <TextField className={classes.textField} value={this.props.counterValue}/>
                <br/><br/>
                <Button variant="raised" color="default" className={classes.button} onClick={this.props.incrementFunction}>
                    increment
                </Button>
                <Button  variant="raised" color="secondary" className={classes.button} onClick={this.props.resetFunction}>
                    reset
                </Button>
                <Button  variant="raised" color="default" className={classes.button} onClick={this.props.decrementFunction}>
                    decrement
                </Button>

            </div>
        );
    }
}

export default withStyles(styles)(Counter);