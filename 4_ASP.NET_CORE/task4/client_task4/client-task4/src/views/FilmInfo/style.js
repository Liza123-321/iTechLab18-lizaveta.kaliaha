const styles = theme => ({
	button: {
		margin: theme.spacing.unit,
		maxHeight: 30,
	},
	title: {
		paddingTop: 15,
		paddingBottom: 20,
		width: 345,
		fontWeight: 600,
		fontFamily: 'Georgia',
		fontSize: 26,
		color: '#ff1a75',
	},
	text: {
		fontFamily: 'Georgia',
		fontSize: 16,
		color: '#222222',
	},
	text_pink: {
		fontFamily: 'Georgia',
		fontSize: 18,
		color: '#ff1a75',
	},
	stars: {
		display: 'flex',
		justifyContent: 'center',
	},
	textPadding: {
		paddingTop: 70,
	},
	container: {
		justify: 'center',
	},
	media: {
		marginRight: 20,
		width: 400,
		height: 600,
	},
	description: {
		paddingLeft: 20,
		paddingRight: 30,
		justifyContent: 'center',
		display: 'flex',
	},
	top: {
		justifyContent: 'center',
		display: 'flex',
	},
	card: {
		paddingBottom: 20,
		display: 'flex',
		margin: 20,
		justifyContent: 'center',
		flexWrap: 'wrap',
		width: 900,
	},
});

export default styles;
