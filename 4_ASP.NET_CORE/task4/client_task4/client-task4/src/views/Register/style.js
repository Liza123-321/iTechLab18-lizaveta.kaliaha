import green from '@material-ui/core/colors/green';
const styles = theme => ({
	button: {
		margin: theme.spacing.unit,
		height: 50,
		width: 150,
	},
	input: {
		display: 'none',
	},
	textField: {
		marginLeft: theme.spacing.unit,
		marginRight: theme.spacing.unit,
		width: 250,
	},
	container: {
		display: 'flex',
		flexWrap: 'wrap',
	},
	textLogin: {
		paddingTop: 25,
		paddingLeft: 80,
		textAlign: 'left',
		paddingBottom: 25,
		fontWeight: 500,
		fontSize: 34,
		backgroundColor: '#e91e63',
		color: 'white',
	},
	text_gray: {
		fontSize: 14,
		color: 'gray',
	},
	authIcon: {
		width: 70,
		height: 70,
	},
	menu: {
		width: 200,
	},
	errors: {
		color: '#e91e63',
	},
	card: {
		marginTop: 30,
		paddingBottom: 30,
		marginLeft: 'auto',
		marginRight: 'auto',
		justifyContent: 'center',
		flexWrap: 'wrap',
		maxWidth: 500,
	},
	inputGroup: {
		marginTop: 30,
		marginBottom: 30,
		paddingBottom: 30,
		backgroundColor: '#ebebeb',
		marginLeft: 'auto',
		marginRight: 'auto',
		paddingTop: 20,
		justifyContent: 'center',
		flexWrap: 'wrap',
		maxWidth: 400,
	},
	formControl: {
		margin: theme.spacing.unit,
		minWidth: 120,
	},
	selectEmpty: {
		marginTop: theme.spacing.unit * 2,
	},
	root: {
		display: 'flex',
		alignItems: 'center',
	},
	wrapper: {
		margin: theme.spacing.unit,
		position: 'relative',
	},
	buttonSuccess: {
		backgroundColor: green[500],
		'&:hover': {
			backgroundColor: green[700],
		},
	},
	close: {
		width: theme.spacing.unit * 4,
		height: theme.spacing.unit * 4,
	},
	fabProgress: {
		color: green[500],
		position: 'absolute',
		top: -6,
		left: -6,
		zIndex: 1,
	},
	buttonProgress: {
		color: green[500],
		position: 'absolute',
		top: '50%',
		left: '50%',
		marginTop: -12,
		marginLeft: -12,
	},
});

export default styles;
