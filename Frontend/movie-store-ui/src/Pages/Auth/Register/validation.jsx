import { object, string, number, date, InferType, ref } from "yup";

export const customerSchema = object({
  firstName: string().required("Zorunlu alan"),
  lastName: string().required("Zorunlu alan").max(100),
  email: string().email("Geçerli bir email giriniz").required("Zorunlu alan"),
  userName: string().required("Zorunlu alan"),
  password: string().required("Zorunlu alan"),
  passwordConfirm: string()
    .required("Zorunlu alan")
    .oneOf([ref("password"), null], "Passwords must match"),
  phoneNumber: number().typeError("Sadece rakam").required("Zorunlu alan"),
});
