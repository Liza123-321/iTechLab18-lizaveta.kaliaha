const styles = theme => ({
	root: {
		display: 'flex',
		flexWrap: 'wrap',
		justifyContent: 'space-around',
		overflow: 'hidden',
		backgroundColor: theme.palette.background.paper,
	},
	gridList: {
		marginLeft: 'auto',
		marginRight: 'auto',
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
		padding: 15,
		width: 870,
	},
});

export default styles;
