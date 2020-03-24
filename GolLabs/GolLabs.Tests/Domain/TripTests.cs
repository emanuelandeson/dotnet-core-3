using GolLabs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GolLabs.Tests.Domain
{

    public class TripTests
    {
        private readonly Trip _trip = new Trip("Emanuel", DateTime.Now.Date, "22:00", "Salvador", "Recife");

        [Fact]
        public void dada_viagem_valida_deve_retornar_true()
        {
            var trip = new Trip("Emanuel", DateTime.Now.Date, "22:00", "Salvador", "Recife");
            Assert.True(trip.IsValid());
        }

        [Fact]
        public void dada_viagem_invalida_deve_retornar_false()
        {
            var trip = new Trip("Emanuel", DateTime.Now.Date, "22:00", "Salvador", "");
            Assert.False(trip.IsValid());
        }

    }
}
