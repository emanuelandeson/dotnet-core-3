using GolLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GolLabs.Tests.Domain
{
    public class UserTests
    {
        [Fact]
        public void dado_usuario_valido_deve_retornar_true()
        {
            var trip = new User("Emanuel", "102030");
            Assert.True(trip.IsValid());
        }

        [Fact]
        public void dado_usuario_invalido_deve_retornar_false()
        {
            var trip = new User("", "102030");
            Assert.False(trip.IsValid());
        }
    }
}
