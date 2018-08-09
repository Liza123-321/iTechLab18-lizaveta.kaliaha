import green from '@material-ui/core/colors/green';
const styles = theme => ({
	button: {
		margin: theme.spacing.unit,
	},
	input: {
		display: 'none',
	},
	textField: {
		marginLeft: theme.spacing.unit,
		marginRight: theme.spacing.unit,
		width: 200,
	},
	container: {
		display: 'flex',
		flexWrap: 'wrap',
	},
	authIcon: {
		width: 70,
		height: 70,
	},
	menu: {
		width: 200,
	},
	errors: {
		color: '#ff1a75',
	},
	card: {
		marginTop: 10,
		marginLeft: 'auto',
		marginRight: 'auto',
		paddingTop: 20,
		justifyContent: 'center',
		flexWrap: 'wrap',
		maxWidth: 1000,
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
