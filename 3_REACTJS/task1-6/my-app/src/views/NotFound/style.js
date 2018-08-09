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
	menu: {
		width: 200,
	},
	card: {
		display: 'flex',
		marginTop: 10,
		marginLeft: 'auto',
		marginRight: 'auto',
		justifyContent: 'center',
		flexWrap: 'wrap',
		maxWidth: 600,
	},
});

export default styles;
