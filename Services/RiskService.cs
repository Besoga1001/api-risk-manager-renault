using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using project_renault.Models;

namespace project_renault.Services
{
    public class RiskService
    {
        DBSettings _context;
        public RiskService(DBSettings context)
        {
            _context = context;
        }

        public async Task<List<RiskModel>> GetAllRisk()
        {
            return await _context.Risk.ToListAsync();
        }

        public async Task<RiskModel> GetByIdRisk(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }

            var risk = await _context.Risk.FindAsync(id);

            if (risk == null)
            {
                throw new Exception();
            }

            return risk;
        }

        public async Task<RiskModel> AddRisk(RiskModel risk)
        {
            try
            {
                await _context.Risk.AddAsync(risk);
                await _context.SaveChangesAsync();

                return risk;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<RiskModel> PutRisk(RiskModel risk)
        {
            try
            {
                _context.Entry(risk).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return risk;
            }
            catch
            {
                throw new Exception();
            }

        }

        public async Task<List<string>?> GetProjects()
        {
            try
            {
                var projetos = await _context.Risk
                    .Select(r => r.Projeto)
                    .Distinct()
                    .ToListAsync();
                return projetos;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<List<string>?> GetMetier()
        {
            try
            {
                var metiers = await _context.Risk
                    .Select(r => r.Metier)
                    .Distinct()
                    .ToListAsync();
                return metiers;
            }
            catch (Exception ex)
            {
                // Opcional: você pode adicionar algum logging aqui
                throw new Exception("An error occurred while getting Jalon", ex);
            }
        }

        public async Task<List<string>?> GetJalon()
        {
            try
            {
                var jalon = await _context.Risk
                    .Select(r => r.JalonAfetado)
                    .Distinct()
                    .ToListAsync();
                return jalon;
            }
            catch (Exception ex)
            {
                // Opcional: você pode adicionar algum logging aqui
                throw new Exception("An error occurred while getting Jalon", ex);
            }
        }

        public async Task<string> ImportJson()
        {
            try
            {
                // Carregar o arquivo JSON
                string jsonFilePath = "risco.json";
                var jsonData = await System.IO.File.ReadAllTextAsync(jsonFilePath);
                var riscos = JsonConvert.DeserializeObject<List<RiskModel>>(jsonData);

                // Adicionar os dados ao contexto
                _context.Risk.AddRange(riscos);
                await _context.SaveChangesAsync();

                return "Dados importados com sucesso.";
            }
            catch (Exception ex)
            {
                return "Erro ao importar dados: {ex.Message}";
            }
        }

        public void EnviarEmail(string assunto, string mensagem) {

            //var nome_usuario = _context.Risk
            //           .Select(u => u.id)
            //           .FirstOrDefault();

            var email = _context.User
                       .Where(u => u.nome == "nome_usuario")
                       .Select(u => u.email)
                       .FirstOrDefault();

            try
            {
                // Configurações do servidor SMTP
                SmtpClient smtpClient = new SmtpClient("smtp.seudominio.com"); // Substitua pelo seu servidor SMTP

                // Credenciais de envio de email (caso necessite de autenticação)
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("seuemail@seudominio.com", "suasenha");

                // Construindo o email
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("user@seudominio.com"); // Substitua pelo seu endereço de email
                mailMessage.To.Add(email);
                mailMessage.Subject = assunto;
                mailMessage.Body = mensagem;
                mailMessage.IsBodyHtml = true; // Se o corpo do email contém HTML

                // Enviando o email
                smtpClient.Send(mailMessage);

                // Exemplo de mensagem de sucesso
                Console.WriteLine("Email enviado com sucesso para " + email);
            }
            catch (Exception ex)
            {
                // Em caso de erro, capturamos a exceção e podemos tratar ou registrar
                Console.WriteLine("Ocorreu um erro ao enviar o email: " + ex.Message);
            }

        }
    }
}
