import React from 'react';
import ReactDOM from 'react-dom';
import { Provider as AlertProvider } from 'react-alert';
import AlertTemplate from 'react-alert-template-basic';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import { createStore, combineReducers, applyMiddleware } from 'redux';
import loginForm from './reducers/index';
import { reducer as formReducer } from 'redux-form';
import thunk from 'redux-thunk';

// optional cofiguration
const options = {
	position: 'bottom right',
	timeout: 2000,
	offset: '30px',
	transition: 'scale',
};

let middleware = applyMiddleware(thunk);
const rootReducer = combineReducers({
	loginForm,
	form: formReducer,
	middleware,
});

const store = createStore(
	rootReducer,
	window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
);

ReactDOM.render(
	<Provider store={store}>
		<BrowserRouter>
			<AlertProvider template={AlertTemplate} {...options}>
				<App />
			</AlertProvider>
		</BrowserRouter>
	</Provider>,
	document.getElementById('root')
);

registerServiceWorker();
