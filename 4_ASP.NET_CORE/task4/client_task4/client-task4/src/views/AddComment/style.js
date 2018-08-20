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
		justifyContent: 'center',
		display: 'flex',
	},
	button: {
		margin: theme.spacing.unit,
		maxHeight: 30,
	},
	card: {
		marginTop: 10,
		display: 'flex',
		justifyContent: 'center',
		flexWrap: 'wrap',
		width: 900,
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
