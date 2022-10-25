using System;
using System.Collections.Generic;
using IE307Week2.Models;
using IE307Week2.Models.AnimalWorld;

namespace IE307Week2.Services.AnimalWorld
{
    public class MockAnimalWorldService : IAnimalWorldService
    {
        private readonly List<AnimalGroupItem> groups = new List<AnimalGroupItem>
        {
            new AnimalGroupItem{ Id = 1, Name = "Birds", Thumbnail = "birds.jpg" },
            new AnimalGroupItem{ Id = 2, Name = "Mammals", Thumbnail = "mammals.jpg" },
            new AnimalGroupItem{ Id = 3, Name = "Reptiles", Thumbnail = "reptiles.jpg" },
        };

        private readonly List<AnimalSpeciesItem> species = new List<AnimalSpeciesItem>
        {
            // Birds
            new AnimalSpeciesItem
            {
                Id = 1,
                GroupId = 1,
                Name = "Garganey",
                Category = "Waterfowl",
                ConservationStatus = "Conservation Concern 4",
                Description = "The garganey is a small dabbling duck, slightly larger than a Teal. They spend the winter in central Africa, with small numbers appearing in the UK between March and October. Breeding pairs favour shallow wetlands, mostly in south and central England. They can be very secretive, preferring areas with lots of cover from aquatic plants. Unlike teal, garganey rarely upend completely when feeding, preferring just to dip their head or skim the surface with their bill.",
                Thumbnail = "garganey.jpg",
            },
            new AnimalSpeciesItem
            {
                Id = 2,
                GroupId = 1,
                Name = "Kestrel",
                Category = "Birds of prey",
                ConservationStatus = "Conservation Concern 4",
                Description = "The kestrel is a little smaller than a Feral Pigeon and can be found in all kinds of habitats, from open countryside to towns and villages. They nest in holes in trees, old buildings and abandoned crows' nests, laying between four and five eggs. When they hatch, both parents help to feed the young chicks.",
                Thumbnail = "kestrel.jpg",
            },

            // Mammals
            new AnimalSpeciesItem
            {
                Id = 3,
                GroupId = 2,
                Name = "Rabbit",
                Category = "Mammals",
                ConservationStatus = "Common",
                Description = "Most people have spotted these adorable animals grazing in long grasses looking for their favourite foods. They were first introduced to the UK by the Normans for food and fur but are now a common sight for many. They live in large groups in underground burrow systems known as ‘warrens’. Female rabbits, called ‘does’ produce one litter of between three and seven babies every month during the breeding season – that’s a lot of little ones! Rabbits make a tasty snack for stoats, buzzards, polecats and red foxes, which is why having a warren to hide in for shelter is so important.",
                Thumbnail = "rabbit.jpg",
            },
            new AnimalSpeciesItem
            {
                Id = 4,
                GroupId = 2,
                Name = "Red fox",
                Category = "Mammals",
                ConservationStatus = "Common",
                Description = "The red fox is our only wild member of the dog family. They are not fussy eaters and will happily munch on small mammals, birds, frogs, worms as well as berries and fruit! Foxes that live in towns and cities may even scavenge in bins to look for scraps. A male fox, called a dog makes a barking noise whereas the females, called vixens make a spine-chilling scream sound.",
                Thumbnail = "red_fox.jpg",
            },

            // Reptiles
            new AnimalSpeciesItem
            {
                Id = 5,
                GroupId = 3,
                Name = "Adder",
                Category = "Retiles",
                ConservationStatus = "Priority Species",
                Description = "The adder is a relatively small, stocky snake that prefers woodland, heathland and moorland habitats. It hunts lizards and small mammals, as well as ground-nesting birds, such as skylark and meadow pipit. In spring, male adders perform a 'dance' during which they duel to fend off competition to mate. Females incubate the eggs internally, 'giving birth' to three to twenty live young. Adders hibernate from October, emerging in the first warm days of March, which is the easiest time of year to find them basking on a log or under a warm rock.",
                Thumbnail = "adder.jpg",
            },
            new AnimalSpeciesItem
            {
                Id = 6,
                GroupId = 3,
                Name = "Smooth snake",
                Category = "Reptiles",
                ConservationStatus = "Priority Species",
                Description = "The rare smooth snake can only be found in a few places, often alongside the rare sand lizard because they both favour the same kind of sandy heathland habitat. As with other reptiles, smooth snakes are ectotherms (their body temperature depends on the temperature of their environment), so bask in the sun during the day and hibernate from October to April when they would struggle to warm up enough to be active and hunt. In spring, males compete to win females who incubate their eggs internally and 'give birth' to 4 to 15 young in September.",
                Thumbnail = "smooth_snake.jpg",
            },
        };

        private static ListViewItem AnimalGroupItemToListViewItem(AnimalGroupItem item)
        {
            return new ListViewItem
            {
                Id = item.Id,
                Text = item.Name,
                Detail = String.Empty,
                Thumbnail = item.Thumbnail,
                IsLeaf = false,
            };
        }

        private static ListViewItem AnimalSpeciesItemToListViewItem(AnimalSpeciesItem item)
        {
            return new ListViewItem
            {
                Id = item.Id,
                Text = item.Name,
                Detail = $"{item.ConservationStatus} | {item.Category}",
                Thumbnail = item.Thumbnail,
                IsLeaf = true,
            };
        }

        private static DetailItem AnimalSpeciesItemToDetailItem(AnimalSpeciesItem item)
        {
            return new DetailItem
            {
                Thumbnail = item.Thumbnail,
                Title = item.Name,
                Description = $"Conversation status: {item.ConservationStatus}\n\n{item.Description}",
            };
        }

        public List<ListViewItem> GetGroups()
        {
            return groups.
                ConvertAll(new Converter<AnimalGroupItem, ListViewItem>(AnimalGroupItemToListViewItem));
        }

        public List<ListViewItem> GetSpeciesByGroupId(int id)
        {
            return species
                .FindAll(s => s.GroupId == id)
                .ConvertAll(new Converter<AnimalSpeciesItem, ListViewItem>(AnimalSpeciesItemToListViewItem));
        }

        public DetailItem GetSpeciesDetailById(int id)
        {
            return AnimalSpeciesItemToDetailItem(species.Find(s => s.Id == id));
        }
    }
}
