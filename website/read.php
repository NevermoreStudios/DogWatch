<?php
	$data = @file_get_contents('data');
	$data = explode("\n", $data);
	global $status, $drinking;
	$status = trim($data[0]);
	$drinking = trim($data[1]) == '1';
?>