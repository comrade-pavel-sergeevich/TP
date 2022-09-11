<?php 
	function emptyField($fiels){
		$result = false;
		foreach ($fiels as $field)
		{
			if (empty($field)){
				$result=true;
				break;
			}
		}
		return $result;
	}
	function existUser($pdo, $email){
		$sql ="SELECT * FROM users WHERE login = ?;";
		$stmt = $pdo->prepare($sql);
		$stmt -> execute([$email]);
		
		if($stmt){
			return($stmt->rowCount()===1);

		}
	}
	function createUser($pdo, $email, $pwd){
		$sql="INSERT INTO users (login, pass) VALUES(?,?);";
		try{
			$stmt = $pdo->prepare($sql);
			$stmt -> execute([$email,$pwd]);
		}
		catch(PDOExpression $e){
			exit();
		}
	}
	function login($pdo, $email, $pwd){
		$sql="SELECT pass FROM users WHERE login=?";
		try{
			$stmt = $pdo->prepare($sql);
			$stmt -> execute([$email]);
		}
		catch(PDOExpression $e){
			header("location: ../index.php?reg_form=login&error=stmt&message=".$e->get);
			echo '<span style = "color:red">фиговый запрос</span>';
			exit();
		}
		try{
		$row = $stmt->fetch(PDO::FETCH_LAZY);if($row!=null){
		$hash = $row['pass'];
		return password_verify($pwd, $hash);}
		}
	catch(PDOExpression $e){}	return false;		
	}
	
	
	
	function getname($pdo,$email){
		$sql="SELECT login FROM users WHERE login=?";
		try{
			$stmt = $pdo->prepare($sql);
			$stmt -> execute([$email]);
		}
		catch(PDOExpression $e){
			header("location: ../index.php?error=stmt&message=".$e->get);
			echo '<span style = "color:red">фиговый запрос</span>';
			exit();
		}
		$row = $stmt->fetch(PDO::FETCH_LAZY);
		return $row->name;
	}
	
	
?>