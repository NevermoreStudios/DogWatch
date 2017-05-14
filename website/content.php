<?php
	require_once 'read.php';
	global $status, $drinking;
	$info = [
		['full', 'Don\'t worry, your dog must be fine!'],
		['half-full', 'Your dog is still happy!'],
		['almost empty', 'You should pour some more water into the bowl!'],
		['empty', 'Oh, my. Your dog must be thirsty!']
	][$status];
?>
<div id="content">
	<h2>Bowl of water is currently</h2>
	<h1 id="bowl" class="status-<?php echo $status; ?>"><?php echo $info[0]; ?></h1>
<?php if($drinking) { ?>
	<h3>Your dog is currently drinking water!</h3>
<?php } else { ?>
	<h3><?php echo $info[1]; ?></h3>
<?php } ?>
	<div id="images">
		<img src="img/drink.png" id="drink" class="<?php echo $drinking ? 'drink' : 'idle'; ?>" />
		<img src="img/dog-<?php echo $status; ?>.png" id="bowlimg" width="285" height="206" />
	</div>
</div>