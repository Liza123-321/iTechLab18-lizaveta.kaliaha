const styles = theme => ({
	root: {
		display: 'flex',
		flexWrap: 'wrap',
		justifyContent: 'space-around',
		overflow: 'hidden',
		backgroundColor: theme.palette.background.paper,
	},
	gridList: {
		width: 850,
	},
	subheader: {
		width: '100%',
	},
	top: {
		flexWrap: 'wrap',
		justifyContent: 'center',
		display: 'flex',
	},
	button: {
		margin: theme.spacing.unit,
		maxHeight: 30,
	},
	userName: {
		paddingTop: 5,
		color: '#834bff',
		fontSize: 16,
	},
	commentMessage: {
		paddingTop: 10,
		paddingLeft: 10,
		fontSize: 16,
	},
	commentData: {
		fontSize: 12,
		paddingTop: 10,
		color: 'grey',
	},
	card: {
		marginTop: 10,
		display: 'flex',
		flexWrap: 'wrap',
		width: 600,
		backgroundColor: 'DarkGrey',
	},
	column: {
		display: 'flex',
		width: 400,
		flexDirection: 'column',
	},
	row: {
		display: 'flex',
		justifyContent: 'center',
	},
	avatar: {
		margin: 10,
		color: '#fff',
		backgroundColor: '#e91e63',
	},
	bigAvatar: {
		width: 60,
		height: 60,
	},
});

export default styles;
