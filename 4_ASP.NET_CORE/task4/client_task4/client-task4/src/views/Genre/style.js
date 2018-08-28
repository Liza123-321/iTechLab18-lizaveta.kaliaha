const styles = theme => ({
	top: {
		justifyContent: 'center',
		flexWrap: 'wrap',
		display: 'flex',
	},
	button: {
		margin: theme.spacing.unit,
		maxHeight: 30,
	},
	userName: {
		paddingTop: 5,
		fontSize: 16,
		'&:hover': {
			color: '#e91e63',
		},
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
		margin: 5,
		padding: 10,
		justifyContent: 'center',
		display: 'flex',
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
