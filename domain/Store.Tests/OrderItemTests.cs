﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentOutOfRange() 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0 ;
                new OrderItem(1, count, 0m);
            }
            );

        }

        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = -1;
                new OrderItem(1, count, 0m);
            }
            );

        }

        [Fact]
        public void OrderItem_WithPositiveCount_ThrowsArgumentOutOfRange()
        {
            var orderItem = new OrderItem(1, 2, 3m);

            Assert.Equal(1, orderItem.BookId);
            Assert.Equal(2, orderItem.Count);
            Assert.Equal(3m, orderItem.Price);
        }
    }
}
