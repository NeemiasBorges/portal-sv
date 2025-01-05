import FormField from "../../Form/Cliente/ModalCadastro/FormField";
import { useForm } from "react-hook-form";
import { loginService } from "../../../services/loginService";

function LoginComponent() {
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm();

  const onSubmitLoginHandler = async (FormData) => {
    try {
      const loginData = {
        email: FormData.Email,
        password: FormData.Senha,
      };

      console.log(loginData);
      const response = await loginService.login(loginData);
      console.log("Login efetuado com sucesso");
      reset();
    } catch (error) {
      console.error("Erro no login:", error.message);
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmitLoginHandler)}>
      <div className="p-2 gap-2 max-w-screen-sm mx-auto shadow-lg border-s-blue-400 rounded-md">
        <div className="mx-auto flex-row justify-center items-center p-5 m-4">
          <FormField
            label="Usuário"
            register={register}
            name="Email"
            type="email"
            validation={{
              required: "email é obrigatório",
              minLength: { value: 3, message: "Mínimo 3 caracteres" },
              maxLength: { value: 100, message: "Máximo 100 caracteres" },
            }}
            errors={errors}
          />

          <FormField
            label="Senha"
            type="password"
            autoComplete="off"
            register={register}
            name="Senha"
            validation={{
              required: "Senha é obrigatória",
              minLength: { value: 3, message: "Mínimo 3 caracteres" },
            }}
            errors={errors}
          />

          <input
            type="submit"
            value="Login"
            className="mt-5 p-4 bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 cursor-pointer block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
          />
        </div>
      </div>
    </form>
  );
}

export default LoginComponent;
