import { useNavigate } from "react-router";
import FormField from "../../Form/Cliente/ModalCadastro/FormField";
import { useForm } from "react-hook-form";
import { loginService } from "../../../services/loginService";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import useAuth from "../../../hooks/useAuth";

function LoginComponent() {
  const navigate = useNavigate();
  const { login } = useAuth();

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

      const response = await loginService.login(loginData);
      const token = response.token || response; // Handle both object and string responses

      // Store token and update auth state
      login(token);

      await new Promise((resolve) => setTimeout(resolve, 2000));
      navigate("/clientes");
      reset();
    } catch (error) {
      console.error("Erro no login:", error.message);
    }
  };

  return (
    <>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
      />

      <form onSubmit={handleSubmit(onSubmitLoginHandler)}>
        <div className="p-2 gap-2 mx-auto shadow-lg border-s-blue-400 rounded-md">
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
    </>
  );
}

export default LoginComponent;
