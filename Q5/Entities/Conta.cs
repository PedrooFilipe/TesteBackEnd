using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q5.Entities;

[Table("contas")]
public class Conta
{
    [Key, Column("id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Column("saldo")]
    public double Saldo { get; set; }

    public Conta(long id, double saldo)
    {
        Id = id;
        Saldo = saldo;
    }

    public bool PodeDebitar(double valor)
    {
        if (Saldo - valor < 0)
        {
            return false;
        }

        return true;
    }

    public void Debite(double valor)
    {
        Saldo -= valor;
    }

    public void Credite(double credite)
    {
        Saldo += credite;
    }
}