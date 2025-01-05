import { loginService } from "../../services/loginService";
import React, { useState, useEffect } from "react";
import Header from "../../components/Header/HeaderComponent";
import TitleComponent from "../../components/TitleComponent";
import LoginComponent from "../../components/Form/Login/loginFormComponent";

function Login() {
  return (
    <div>
      <Header />
      <TitleComponent>Execute o login</TitleComponent>
      <LoginComponent />
    </div>
  );
}

export default Login;
