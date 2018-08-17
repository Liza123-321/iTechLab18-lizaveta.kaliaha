import React from 'react';
import MyRouter from '../views/Router/index';

import {
	BrowserRouter as Router,
	Route,
	Switch,
	withRouter,
	Redirect,
} from 'react-router-dom';
import NotFound from '../views/NotFound/index';
import Login from './LoginContainer';
import FilmsContainer from './FilmsContainer';
import FilmContainer from './FilmContainer';

const VIRTUAL_PATH = '/React_task1';
const pathNameTab = [
	{
		pathName: '/React_task1/films',
		activeTabValue: 0,
	},
	{
		pathName: '/React_task1/login',
		activeTabValue: 1,
	},
	{
		pathName: '/React_task1/',
		activeTabValue: false,
	},
];
class RouterContainer extends React.Component {
	constructor(props) {
		super(props);
		this.handleChange = this.handleChange.bind(this);
		this.state = {
			activeTabValue: false,
			login: 'anon',
			password: 'anon',
			viewToolbar: true,
		};
	}

	handleChange = (event, value) => {
		this.setState({ activeTabValue: value });
	};

	componentWillMount() {
		pathNameTab.map(x => {
			if (this.props.history.location.pathname === x.pathName) {
				this.setState({ activeTabValue: x.activeTabValue });
			}
		});
	}

	render() {
		return (
			<Router>
				<div>
					<MyRouter
						activeTabValue={this.state.activeTabValue}
						handleChange={this.handleChange}
						login={this.state.login}
						password={this.state.password}
						viewToolbar={this.state.viewToolbar}
					/>
					<Switch>
						<Route exact path={VIRTUAL_PATH + '/'} component={null} />
						<Route path={VIRTUAL_PATH + '/film/'} component={FilmContainer} />
						<Route path={VIRTUAL_PATH + '/films'} component={FilmsContainer} />
						<Route path={VIRTUAL_PATH + '/login'} component={Login} />
						<Route path={VIRTUAL_PATH + '/404'} component={NotFound} />
						<Route
							path={VIRTUAL_PATH + '/*'}
							render={() => <Redirect to={VIRTUAL_PATH + '/404'} />}
						/>
						<Route
							path="/*"
							render={() => <Redirect to={VIRTUAL_PATH + '/'} />}
						/>
					</Switch>
				</div>
			</Router>
		);
	}
}

export default withRouter(RouterContainer);
