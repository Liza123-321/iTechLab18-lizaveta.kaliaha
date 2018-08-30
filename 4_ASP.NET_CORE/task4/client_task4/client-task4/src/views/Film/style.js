const styles = theme => ({
	button: {
		margin: theme.spacing.unit,
		maxHeight: 30,
	},
	title: {
		width: 345,
	},
	container: {
		justify: 'center',
	},
	media: {
		height: '80%',
		width: '100%',
	},
	card: {
		paddingBottom: 20,
		display: 'flex',
		margin: 20,
		justifyContent: 'center',
		flexWrap: 'wrap',
		width: 345,
		height: 650,
		'&:hover': {
			width: 400,
			height: 700,
		},
	},
	stars: {
		display: 'flex',
		justifyContent: 'center',
	},
});

export default styles;
