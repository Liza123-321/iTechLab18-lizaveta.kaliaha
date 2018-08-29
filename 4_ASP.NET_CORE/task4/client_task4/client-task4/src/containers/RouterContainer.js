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
import Register from './RegisterContainer';
import FilmsContainer from './FilmsContainer';
import LogOutContainer from './LogOutContainer';
import FilmContainer from './FilmContainer';

const pathNameTab = [
	{
		pathName: '/films',
		activeTabValue: 0,
	},
	{
		pathName: '/login',
		activeTabValue: 1,
	},
	{
		pathName: '/logout',
		activeTabValue: 1,
	},
	{
		pathName: '/',
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
			isAuth: sessionStorage.getItem('jwt_token') != null,
		};
	}

	handleChange = (event, value) => {
		this.setState({ activeTabValue: value });
		this.setState({ isAuth: sessionStorage.getItem('jwt_token') != null });
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
						isAuth={this.state.isAuth}
					/>
					<Switch>
						<Route path={'/films'} component={FilmsContainer} />
						<Route path={'/film/:id'} component={FilmContainer} />
						<Route path={'/register'} component={Register} />
						<Route path={'/logout'} component={LogOutContainer} />
						<Route path={'/login'} component={Login} />
						<Route path={'/404'} component={NotFound} />
						<Route path={'/*'} render={() => <Redirect to={'/404'} />} />
					</Switch>
				</div>
			</Router>
		);
	}
}

export default withRouter(RouterContainer);
