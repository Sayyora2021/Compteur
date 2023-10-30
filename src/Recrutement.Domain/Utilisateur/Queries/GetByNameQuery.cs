using MediatR;


namespace Recrutement.Domain.Utilisateur.Queries;

public class GetByNameQuery : IRequest<Models.Utilisateur>
{
    
    public string Name { get; set; }

    public GetByNameQuery(string name)
    {
       
        Name = name;
    }
}





