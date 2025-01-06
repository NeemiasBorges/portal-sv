import Header from "../../components/Header/HeaderComponent";
import TitleComponent from "../../components/TitleComponent";
import LoginComponent from "../../components/Form/Login/loginFormComponent";

function Login() {
  return (
    <div>
      <Header />
      <TitleComponent>Acesse o Sistema</TitleComponent>
      <div className="container max-w-5xl mx-auto">
        <LoginComponent />
      </div>
    </div>
  );
}

export default Login;
