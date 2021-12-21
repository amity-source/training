// 1. check
// alert("hello");

let username_C = false;
let pass_C = false;
let rePass_C = false;
let email_C = false;

// 2. setup button
$(document).ready(function () {
  $("button").on("click", function() {
    // console.log("button clicked!");

    run($(this));

  })
})

function run(button){

  let form = button.closest("form");
  //get value from input by getValue
  let name = getValue(form,"username");
  let password = getValue(form,"password");
  let retypePassword = getValue(form,"retype-password");
  let email = getValue(form,"email");
  let phoneNumber = getValue(form,"phone-number");
  let address = getValue(form,"address");

  // only check name, password, retypePassword, email
  checkValue(name,password,retypePassword,email);

  console.log(" username_C: " +username_C+
  "\n pass_C: " +pass_C+
  "\n rePass_C: " +rePass_C+
  "\n email_C: " +email_C);

  // set input value on the resTable
  setValue(name,email,phoneNumber,address);

}

function getValue(target,elm){
  let value = target.find(`input[name=${elm}]`).val();
  return value;
}

function checkValue(username,pass,retypepass,email){
  //a. check if username more than 4 char
  if(username.length >= 4){
    username_C = true;
    console.log("name clear");
    //b. check if password is null
    if(pass){
      pass_C = true;
      console.log("password clear");
      //c. check if retype-password = password
      if(retypepass === pass){
        rePass_C = true;
        console.log("retype-password clear");
        //d. check if Email is null
        if(email){
          email_C = true;
          console.log("email clear");

        }else{ alert("Email không được trống") } //---email
      }else{ alert("Mật khẩu nhập lại phải giống mật khẩu ở trên") }//---retype-pass
    }else{ alert("Mật khẩu không được trống") } //---pass
  }else{ alert("Tên đăng nhập phải lớn hơn 4 ký tự") }//---username

}

function setValue(username,email,phone,address){
  // check if username, pass, repass & email check is true then run
  if (username_C && pass_C && rePass_C && email_C) {
    $("#resName").text(username);
    $("#resEmail").text(email);
    $("#resPhoneNum").text(phone);
    $("#resAddress").text(address);
  }
  // reset conditions
  username_C = false;
  pass_C = false;
  rePass_C = false;
  email_C = false;
}
