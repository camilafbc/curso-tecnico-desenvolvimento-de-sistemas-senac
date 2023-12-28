const email = document.getElementById("email");
const password = document.getElementById("password");
const input_check = document.getElementById("check");
const button = document.getElementById("btn_login");

function criptografarDados(entrada) {
  const key = "chave-de-criptografia-secreta";
  const dataBytes = CryptoJS.enc.Utf8.parse(entrada);
  const encryptedData = CryptoJS.AES.encrypt(dataBytes, key, {
    mode: CryptoJS.mode.ECB,
  }).toString();
  return encryptedData;
}

function descriptografarDados(entrada) {
  const key = "chave-de-criptografia-secreta";
  const decryptedDataBytes = CryptoJS.AES.decrypt(entrada, key, {
    mode: CryptoJS.mode.ECB,
  }).toString(CryptoJS.enc.Utf8);
  return decryptedDataBytes;
}

if (localStorage.hasOwnProperty("login-data")) {
  let login = JSON.parse(localStorage.getItem("login-data"));

  if (login[0] && login[1]) {
    email.value = descriptografarDados(login[0]);
    password.value = descriptografarDados(login[1]);
    input_check.checked = true;
  }
}

input_check.addEventListener("change", () => {
  if (input_check.checked && !localStorage.hasOwnProperty("login-data") && email.value != "" && password.value != "") {
    let login = [criptografarDados(email.value),criptografarDados(password.value)];
    localStorage.setItem("login-data", JSON.stringify(login));
  }
});