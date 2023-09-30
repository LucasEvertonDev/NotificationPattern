namespace Architecture.Application.Domain.Constants;

public class PessoaValidations
{
    public static NotificationModel NomeObrigatorio = new NotificationModel("NomeObrigatorio", "Nome é obrigatório");

    public static NotificationModel EmailObrigatorio = new NotificationModel("EmailObrigatorio", "Email é obrigatório");

    public static NotificationModel EmailInválido = new NotificationModel("EmailInválido", "Email Inválido");

}