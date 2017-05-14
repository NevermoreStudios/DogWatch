<?php
	require_once 'read.php';
	global $status, $drinking;
	$json = isset($_GET['json']);
	if($json) {
		echo json_encode([
			'status' => $status,
			'drinking' => $drinking
		]);
	} else {
?>
<html>
	<head>
		<title>DogWatch</title>
		<meta charset="utf-8" />
		<link rel="stylesheet" href="css/main.css" type="text/css" />
		<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Underdog" />
		<link rel="shortcut icon" href="favicon.ico" />
		<script src="js/main.js" type="text/javascript"></script>
	</head>
	<body>
		<div id="wrapper">
			<header>
				<h1>
					<img src="img/dog.png" />
					DogWatch
					<img src="img/dog.png" />
				</h1>
				<h2>Watch your dog wherever you are</h2>
				
			</header>
			<?php require_once 'content.php'; ?>
			<footer>
				Copyright &copy; Nevermore Inc. 2017.
			</footer>
		</div>
		<!-- This part of document is caching images that get switched -->
		<div id="cache">
			<img src="img/dog-0.png" />
			<img src="img/dog-1.png" />
			<img src="img/dog-2.png" />
			<img src="img/dog-3.png" />
			<img src="img/drink.png" />
		</div>
	</body>
</html>
<?php
	}
?>