using Microsoft.EntityFrameworkCore;
using project_renault.Models;
using System.Net.Mail;

namespace project_renault.Services
{
    public class SolutionService
    {
        DBSettings _context;
        RiskService riskService;
        public SolutionService(DBSettings context, RiskService riskService)
        {
            _context = context;
            this.riskService = riskService;
        }

        public async Task<List<SolutionModel>> GetAllSolution()
        {
            return await _context.Solution.ToListAsync();
        }

        public async Task<SolutionModel> GetByIdSolution(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }

            var solution = await _context.Solution.FindAsync(id);

            if (solution == null)
            {
                throw new Exception();
            }

            return solution;
        }

        public async Task<SolutionModel> AddSolution(SolutionModel solution)
        {
            try
            {
                await _context.Solution.AddAsync(solution);
                await _context.SaveChangesAsync();

                RiskModel? risk = await _context.Risk.FindAsync(solution.id_risk);
                if (risk == null)
                {
                    throw new Exception();
                }
                risk.id_solution = solution.Id_Solution;
                var resp = await riskService.PutRisk(risk);
                await _context.SaveChangesAsync();

                return solution;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<SolutionModel> PutSolution(SolutionModel solution)
        {
            try
            {
                _context.Entry(solution).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return solution;
            }
            catch
            {
                throw new Exception();
            }

        }

        public void EnviarEmail(string assunto, string mensagem)
        {

            var nome_usuario = _context.Solution
                       .Select(u => u.id_risk)
                       .FirstOrDefault();

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
