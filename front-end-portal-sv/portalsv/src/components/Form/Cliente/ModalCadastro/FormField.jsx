const FormField = ({
  label,
  type = "text",
  register,
  name,
  validation,
  errors,
}) => (
  <div>
    <label className="block text-sm font-medium text-gray-700">{label}</label>
    <input
      type={type}
      {...register(name, validation)}
      className="py-2 px-3 mt-1 block w-full border shadow-sm rounded-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
    />
    {errors[name] && (
      <span className="text-red-500 text-sm">{errors[name].message}</span>
    )}
  </div>
);

export default FormField;
