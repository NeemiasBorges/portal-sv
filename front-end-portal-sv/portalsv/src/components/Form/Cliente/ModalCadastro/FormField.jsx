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
      className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
    />
    {errors[name] && (
      <span className="text-red-500 text-sm">{errors[name].message}</span>
    )}
  </div>
);

export default FormField;
