
function GetComment()
{
	var hoten = document.getElementsByName("hoten")[0].value;
	var binhluan = document.getElementsByName("binhluan")[0].value;
	var noidung = document.getElementsByName("noidung")[0].value;
	var temp = hoten +": "+binhluan;
	document.getElementsByName("noidung")[0].value += "\n"+temp;
	
}